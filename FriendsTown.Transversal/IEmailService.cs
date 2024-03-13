using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsTown.Transversal
{
    public interface IEmailService
    {
        void SendEmail(string from, string to, string subject, string message);
    }
}
