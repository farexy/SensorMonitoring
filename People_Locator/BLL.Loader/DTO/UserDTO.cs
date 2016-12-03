using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Loader.DTO;

namespace BLL.Loader.DTO
{
    public class UserDTO : BaseDTO
    {
        public int Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }

        // path to actions inside DAL tier
        internal override string pathToActions
        {
            get { return "user"; }
        }

    }
}