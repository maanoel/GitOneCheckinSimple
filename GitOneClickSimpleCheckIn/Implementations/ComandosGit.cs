using System;

namespace GitOneClickSimpleCheckIn
{
  public static class ComandosGit
  {
    public static string PrimeiroCommit(string comando)
    {
      return $@"
         echo ""# ASPNETCore2-Parte3-master"" >> README.md
         git init
         git add README.md
         git commit -m ""first commit""
         git branch -M main
         git remote add origin {comando}
         git push -u origin main";
    }

    public static string Commit(string comando)
    {
      return
        $@"
      git add .
      git commit -m ""{comando}""
      git push origin main";
    }

    public static string Status() {
     return $@"git status";
    }

    public  static string Rollback()
    {
      return $@"git checkout .";
    }
  }
}
