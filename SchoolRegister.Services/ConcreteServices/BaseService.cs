using AutoMapper;
using SchoolRegister.DAL.EF;
using Microsoft.Extensions.Logging;
public abstract class BaseService
{
    protected readonly ApplicationDbContext DbContext;
    protected readonly ILogger Logger;
    protected readonly IMapper Mapper;

public BaseService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
    {
        DbContext = dbContext;
        Mapper = mapper;
        Logger = logger;
    }
}