namespace ImpactMan.Models.Players
{
    public class ChangePasswordModel
    {
        private string oldPassword;
        private string newPassword;

        public ChangePasswordModel(string oldPassword, string newPassword)
        {
            this.OldPassword = oldPassword;
            this.NewPassword = newPassword;
        }

        public string OldPassword { get => this.oldPassword; set => this.oldPassword = value; }
        public string NewPassword { get => this.newPassword; set => this.newPassword = value; }
    }
}
