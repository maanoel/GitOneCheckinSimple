namespace GitOneClickSimpleCheckIn
{
  public static class GitCommands
  {
    public static string PrimeiroCommit(string comando)
    {
      return $@"git init
         git add README.md
         git commit - m ""first commit""
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
  }
}
