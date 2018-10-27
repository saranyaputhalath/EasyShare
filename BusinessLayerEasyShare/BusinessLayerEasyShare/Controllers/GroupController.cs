using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DALEasyShare.Group;
using EntityEasyShare;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayerEasyShare.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        GroupRepository objGR = new GroupRepository();


        
        [HttpGet]
        public void AddGroup(string groupName, List<UserEntity> users)
        {
            objGR.CreateGroup(groupName, users);
        }
    }
}