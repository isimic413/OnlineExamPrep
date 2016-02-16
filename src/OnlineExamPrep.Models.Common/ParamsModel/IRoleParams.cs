using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IRoleParams
    {
        string Id { get; set; }
        string Name { get; set; }
        ICollection<IUser> Users { get; set; }
    }
}
