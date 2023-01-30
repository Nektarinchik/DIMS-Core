using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using TaskEntity = DIMS_Core.DataAccessLayer.Models.Task;
namespace DIMS_Core.BusinessLayer.MappingProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskEntity, TaskModel>().ReverseMap();
    }
}