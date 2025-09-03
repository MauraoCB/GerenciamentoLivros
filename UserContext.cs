public static class UserContext 
{
    public static string GetCurrentUser()
    {
        return Environment.UserName;
      
    }
}