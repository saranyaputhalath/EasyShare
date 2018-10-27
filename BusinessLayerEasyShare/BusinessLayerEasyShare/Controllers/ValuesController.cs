using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayerEasyShare.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayerEasyShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //// GET api/values/GetAllCategory
        [HttpGet]
        public ActionResult<List<CategoryDetail>> GetAllCategory()
        {
            try
            {
                List<CategoryDetail> categoryDetails = new List<CategoryDetail>();
                DataTable data = DALEasyShare.DataAccess.GetAllCategory();

                foreach (DataRow row in data.Rows)
                {
                    CategoryDetail category = new CategoryDetail();
                    category.Id = Convert.ToInt32(row["Id"]);
                    category.Name = row["Name"].ToString();
                    categoryDetails.Add(category);
                }

                return categoryDetails;
            }
            catch (Exception ex)
            {
                //log the error for debugging
                return null;
            }
        }

        // GET api/values/GetAllGroupsDetailByUserId
        [HttpGet]
        public ActionResult<Dictionary<int, GroupDetail>> GetAllGroupsDetailByUserId(int userId)
        {
            try
            {
                Dictionary<int, GroupDetail> groupDetails = new Dictionary<int, GroupDetail>();
                DataTable data = DALEasyShare.DataAccess.GetAllGroupsDetailByUserId(userId);

                foreach (DataRow row in data.Rows)
                {
                    if (groupDetails.ContainsKey(Convert.ToInt32(row["GroupId"])))
                    {
                        groupDetails[Convert.ToInt32(row["GroupId"])].TotalSpendInGroup += Convert.ToDecimal(row["Amount"]);
                    }
                    else
                    {
                        GroupDetail group = new GroupDetail();
                        group.GroupName = row["GroupName"].ToString();
                        group.TotalSpendInGroup = Convert.ToDecimal(row["Amount"]);

                        groupDetails.Add(Convert.ToInt32(row["GroupId"]), group);
                    }
                }

                return groupDetails;
            }
            catch (Exception ex)
            {
                //log the error for debugging
                return null;
            }
        }
    }
}
