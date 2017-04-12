namespace BusinessLayer.Infrastructure
{
    public static class SecurityRoles
    {
        public const string Admin     = ST.DAL.Identity.SecurityRoles.Admin;
        public const string Developer = ST.DAL.Identity.SecurityRoles.Developer;
        public const string Manager   = ST.DAL.Identity.SecurityRoles.Manager;
    }
}
