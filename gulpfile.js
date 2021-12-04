var gulp = require("gulp");
var tap = require("gulp-tap");
var argv = require("yargs").argv;
var xml2js = require("xml2js");
var fs = require("fs");
var path = require("path");
var through = require("through2");
var exec = require("child_process").exec;
const versionNumber = require("./node_modules/virteom.public.common-gulp-tasks/gulp_tasks/get-version-info.js").Version.FullSemVer;

require("es6-promise").polyfill();

gulp.task("npm-install",
    function () {
        return gulp.src(["./*/package.json"])
            .pipe(through.obj(function (chunk, encoding, callback) {
                console.log(`Installing packages for: ${chunk.path}`);
                const packagesFile = ".\\third-party-archiving.ps1";

                if (fs.existsSync(packagesFile)) {
                    const matches = chunk.path.match(new RegExp("([A-Za-z0-9_ \:\.\\\\]+)\\\\package\.json$"));
                    const match = matches[1];

                    exec(`Powershell.exe -File "${packagesFile}" -ConfigJsonName "package" -DirectoryName "node_modules" -PackageFramework "npm" -WorkingDirectory "${match}"`,
                        function (err, stdout, stderr) {
                            console.log(stdout);
                            if (stderr !== null) {
                                console.log(stderr);
                            }
                            callback(null, chunk);
                        });
                } else {
                    console.log(`##vso[task.logissue type=error;]ERROR: "${packagesFile}" file not found.`);
                    callback(null, chunk);
                }
            }));
    });

gulp.task("run-projects-tasks",
    function () {
        const taskName = (argv.taskName === undefined || argv.taskName === null || argv.taskName.trim() === "")
            ? "production"
            : argv.taskName.trim().toLowerCase();
        const environment =
            (argv.environment === undefined || argv.environment === null || argv.environment.trim() === "")
                ? "develop"
                : argv.environment.trim().toLowerCase();

        const gulpCommand =
            (argv.gulpCommand === undefined || argv.gulpCommand === null || argv.gulpCommand.trim() === "")
                ? "gulp"
                : argv.gulpCommand.trim();
        var exec = require("child_process").exec;

        return gulp.src(["./*/gulpfile.js"])
            .pipe(tap(function (file) {
                if (file.contents.toString().indexOf(taskName) !== -1) {
                    exec(`${gulpCommand} ${taskName} --gulpfile "${file.path}" --environment=${environment}`,
                        function (error, stdout, stderr) {
                            console.log(stdout);
                        });
                }
            }));
    });

gulp.task("run-solution-version",
    function () {
        argv = { taskName: "version" };
        gulp.start("run-projects-tasks");
    });

gulp.task("run-solution-copy-project-libs-to-plugin",
    function () {
        argv = { taskName: "copy-project-libs-to-plugin" };
        gulp.start("run-projects-tasks");
    });

gulp.task("run-solution-microservice-version",
    function () {
        var parser = new xml2js.Parser();
        var xmlBuilder = new xml2js.Builder();

        console.log("Microservice Version: " + versionNumber);
        gulp.src(["./*/ApplicationPackageRoot/ApplicationManifest.xml"])
            .pipe(tap(function (configFile, t) {
                console.log("Service Fabric **app** manifest file file found: " + configFile.path);
                fs.readFile(configFile.path,
                    function (err, data) {
                        parser.parseString(data,
                            function (err, json) {
                                if (argv.verbose !== undefined) {
                                    console.log("Service Fabric **app** manifest file data prior to change:");
                                    console.log(JSON.stringify(json));
                                }

                                json.ApplicationManifest.$["ApplicationTypeVersion"] = versionNumber;
                                for (var i = 0; i < json.ApplicationManifest.ServiceManifestImport.length; i++) {
                                    var serviceManifest = json.ApplicationManifest.ServiceManifestImport[i]
                                        .ServiceManifestRef[0];
                                    serviceManifest.$["ServiceManifestVersion"] = versionNumber;
                                }

                                if (argv.verbose !== undefined) {
                                    console.log("Service Fabric **app** manifest file data after change:");
                                    console.log(JSON.stringify(json));
                                }

                                var xml = xmlBuilder.buildObject(json);
                                fs.writeFileSync(configFile.path, xml);
                                console.log("Service Fabric **app** manifest file written");
                            });
                    });
            }));

        return gulp.src(["./*/PackageRoot/ServiceManifest.xml"])
            .pipe(tap(function (configFile, t) {
                console.log("Service Fabric **service** manifest file file found: " + configFile.path);
                fs.readFile(configFile.path,
                    function (err, data) {
                        parser.parseString(data,
                            function (err, json) {
                                if (argv.verbose !== undefined) {
                                    console.log("Service Fabric **service** manifest file data prior to change:");
                                    console.log(JSON.stringify(json));
                                }

                                json.ServiceManifest.$["Version"] = versionNumber;

                                var codePackage = json.ServiceManifest.CodePackage[0];
                                codePackage.$["Version"] = versionNumber;

                                var configPackage = json.ServiceManifest.ConfigPackage[0];
                                configPackage.$["Version"] = versionNumber;

                                if (argv.verbose !== undefined) {
                                    console.log("Service Fabric **service** manifest file data after change:");
                                    console.log(JSON.stringify(json));
                                }

                                var xml = xmlBuilder.buildObject(json);
                                fs.writeFileSync(configFile.path, xml);
                                console.log("Service Fabric **service** manifest file written");
                            });
                    });
            }));
    });