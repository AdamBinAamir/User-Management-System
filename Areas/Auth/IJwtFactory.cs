namespace SummerProgramDemo.Areas.Auth
{
    public interface IJwtFactory
    {
        Token GenerateEncodedToken(string id, string userName, Guid? tenantId, string role);
    }
}
