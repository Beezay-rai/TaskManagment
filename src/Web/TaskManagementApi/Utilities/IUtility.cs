namespace TaskManagementApi.Utilities
{
    public interface IUtility
    {
        string GenerateToken(Dictionary<string,object>UserDetails);
        void GenerateRefreshToken(string token);
    }
}
