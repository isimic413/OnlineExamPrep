using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class RoleParams : OnlineExamPrep.Models.Common.ParamsModel.IRoleParams
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<IUser> Users { get; set; }
    }
}
