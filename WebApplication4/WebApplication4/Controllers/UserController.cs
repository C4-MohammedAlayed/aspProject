using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Model;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        db DB = new db();

        [HttpGet]
        public List<User> GetUser()
        {
            List<User> UserLists = new List<User>();
            User user = new User();
            
            DataSet ds = DB.GetUsers(user);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                UserLists.Add(new User
                {
                    id = Convert.ToInt32(dr["id"]),
                    UserName = dr["UserName"].ToString(),
                    firstname= dr["firstname"].ToString(),
                    lastname=dr["lastname"].ToString(),
                    Password=dr["Password"].ToString(),
                    dob= dr["dob"].ToString(),
                    role= dr["role"].ToString(),
                    contactno= dr["contactno"].ToString(),
                    gender= dr["gender"].ToString(),
                    Email = dr["Email"].ToString(),
                }); 
            }
            return UserLists;
        }

        [HttpGet("{id}")]
        public List<User> GetUserBYID(int id)
        {
            List<User> UserList = new List<User>();
            User user = new User();
         
            user.id = id;
            DataSet ds = DB.GetUsers(user);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                UserList.Add(new User
                {
                    id = Convert.ToInt32(dr["id"]),
                    UserName = dr["UserName"].ToString(),
                    firstname = dr["firstname"].ToString(),
                    lastname = dr["lastname"].ToString(),
                    Password = dr["Password"].ToString(),
                    dob = dr["dob"].ToString(),
                    role = dr["role"].ToString(),
                    contactno = dr["contactno"].ToString(),
                    gender = dr["gender"].ToString(),
                    Email = dr["Email"].ToString(),
                });
            }
            return UserList;
        }


        [HttpPost]
        public string AddUser([FromBody] User user)
           
        {
           string Message = string.Empty;
            try
            {
                Message= DB.AddUser(user);// this function will return message if success or field
                 
            }
            catch (Exception ex)
            {

                Message=ex.Message;
            }
            return Message;
        }

    }
}
