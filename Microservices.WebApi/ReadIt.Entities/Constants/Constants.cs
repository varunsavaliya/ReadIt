using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadIt.Core.Constants
{
    public static class Constants
    {
        public static string MediaPath = "D:\\Projects\\Microservices.WebApi\\Gateway.WebApi\\";
    }

    public static class Messages
    {
        public const string SuccessMessage = "{0} successfully";
        public const string NewItemMessage = "New {0} added successfully";
        public const string ErrorMessage = "Error occured while retriving {0}";
        public const string NoItemMessage = "No item found";
        public const string UpdateMessage = "{0} updated successfully";
        public const string DeleteMessage = "{0} deleted successfully";
    }

    public static class AuthMessages
    {
        public const string SignUpMessage = "Account registered successfully. Welcome aboard!";
        public const string LogInMessage = "Account logged in successfully. Welcome aboard!";
    }
}
