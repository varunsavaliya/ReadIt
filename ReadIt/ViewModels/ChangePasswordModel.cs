namespace ReadIt.ViewModels
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public long UserId { get; set; }
    }
}
