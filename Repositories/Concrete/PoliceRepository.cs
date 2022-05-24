using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class PoliceRepository:ExcelRepositoryBase<Police>,IPoliceRepository
{
    
}