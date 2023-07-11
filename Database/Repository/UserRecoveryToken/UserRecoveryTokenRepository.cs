namespace SLVS.Database.Repository.UserRecoveryToken
{
    public class UserRecoveryTokenRepository : Repository, IUserRecoveryTokenRepository
    {
        public UserRecoveryTokenRepository(SlvsContext db) : base(db)
        {
        }
    }
}
