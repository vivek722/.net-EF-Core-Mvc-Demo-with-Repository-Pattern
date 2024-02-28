using Microsoft.AspNetCore.Mvc;
using EmployeeDemo.Domain.Employee;
using EmployeeDemo.EF;
using AutoMapper;
using EmployeeDemo.Web.Models;
using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.IdentityModel.Tokens;


namespace EmployeeDemo.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesService employeesService;

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper _mapper;


        public EmployeesController(EmployeesService employeesService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.employeesService = employeesService;
            this._mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;

        }
        //display data
        public async Task<IActionResult> Index(string searchData)
        {
            var Employees = await employeesService.GetEmployees();
            var EmployeesMapper = _mapper.Map<List<EmployeeDto>>(Employees);

            if (!searchData.IsNullOrEmpty())
            {
                Employees = await employeesService.searchData(searchData);
                EmployeesMapper = _mapper.Map<List<EmployeeDto>>(Employees);
                return View(EmployeesMapper);
            }
            //return Ok(EmployeesMapper);
                return View(EmployeesMapper);
        }
        //find data by id
        public async Task<IActionResult> GetbyId(int id)
        {
            var Employee = await employeesService.GetEmployeeById(id);
            var EmployeeMapper = _mapper.Map<EmployeeDto>(Employee);
            //return View(EmployeeMapper);
            return Ok(EmployeeMapper);
        }

        public IActionResult Insert()
        {
            return View();
        }
        //use to return data in textbox to delete
        [HttpPost]
        public async Task<IActionResult> Insert(EmployeeDto employeeViewModel, IFormFile? Image)
        {

            if (Image != null)
            {
                string upLoadFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(upLoadFolder))
                {
                    Directory.CreateDirectory(upLoadFolder);

                }
                string fileName = Path.GetFileName(Image.FileName);
                employeeViewModel.Image = fileName;
                string fileSavePath = Path.Combine(upLoadFolder, fileName);

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
            }
            List<Skill> skillsList = new List<Skill>();
            if (!string.IsNullOrEmpty(employeeViewModel.Skill_Name))
            {
                var skills = employeeViewModel.Skill_Name.Split(",");
                foreach (var skill in skills)
                {
                    Skill skillData = new Skill();
                    skillData.skill_name = skill.Trim();
                    skillsList.Add(skillData);
                }
            }
            var employee = _mapper.Map<Employee>(employeeViewModel);
            employee.Skills = skillsList;
            _mapper.Map<EmployeeDto>(await employeesService.AddEmployee(employee));
            //TempData["success"] = "Employee Data Insert Successfully";
            //return Ok();
            return RedirectToAction("Index");

        }
        [HttpDelete]
        //use to delete the data
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await employeesService.DeleteEmployee(id);
            var exstingEmployee = _mapper.Map<EmployeeDto>(employee);        
            DeleteFile(exstingEmployee);         
            //TempData["success"] = "Employee Data Delete Successfully";
            //return Ok();
            return RedirectToAction("Index");
        }


        //use to return data in textbox to update
        public async Task<IActionResult> Update(int id)
        {
            var exstingData = await employeesService.GetEmployeeById(id);
            var employee = _mapper.Map<EmployeeDto>(exstingData);
            return View(employee);
        }

        //use to update the data
        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdatePost(int id,EmployeeDto employeeViewModel, IFormFile? Image)
        {
            var exstingData = await employeesService.GetEmployeeById(id);
            var employeeData = _mapper.Map<EmployeeDto>(exstingData);
            var oldImage = employeeData.Image;
            if (Image != null)
            {
                if (employeeData.Image != null)
                {
                    DeleteFile(employeeData);
                    string upLoadFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(upLoadFolder))
                    {
                        Directory.CreateDirectory(upLoadFolder);
                    }
                    string fileName = Path.GetFileName(Image.FileName);
                    employeeViewModel.Image = fileName;
                    string fileSavePath = Path.Combine(upLoadFolder, fileName);
                    using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                }
                else
                {
                    employeeViewModel.Image = oldImage;
                }
            }
            if (!string.IsNullOrEmpty(employeeData.Skill_Name))
            {
                await employeesService.DeleteSkill(id);
            }
            List<Skill> skillsList = new List<Skill>();
            if (!string.IsNullOrEmpty(employeeViewModel.Skill_Name))
            {
                var skills = employeeViewModel.Skill_Name.Split(",");
                foreach (var skill in skills)
                {
                    Skill skillData = new Skill();
                    skillData.skill_name = skill.Trim();
                    skillData.EmployeeId = id;
                    skillsList.Add(skillData);
                }
            }
            var employee = _mapper.Map<Employee>(employeeViewModel);
            employee.Skills = skillsList;
            _mapper.Map<EmployeeDto>(await employeesService.UpdateEmployee(id, employee));
            //TempData["success"] = "Employee Data Update Successfully";
            return RedirectToAction("Index");            
        }
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var exstingEmployeeSkill = await employeesService.DeleteSkill(id);
            var employee = _mapper.Map<List<SkillDto>>(exstingEmployeeSkill);
            return Ok();
            //return RedirectToAction("Index");
        }

        private void DeleteFile(EmployeeDto employeeData)
        {
            employeeData.Image = Path.Combine(webHostEnvironment.WebRootPath, "uploads", employeeData.Image);
            FileInfo fi = new FileInfo(employeeData.Image);
            if (fi.Exists)
            {
                System.IO.File.Delete(employeeData.Image);
                fi.Delete();
            }
        }
        public async Task<IActionResult> getSkillById(int id)
        {
           var DeleteSkill = _mapper.Map<List<SkillDto>>(await employeesService.getSkillsById(id));
           return Ok(DeleteSkill);
            //return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var Employees = await employeesService.GetEmployees();
            var EmployeesMapper = _mapper.Map<List<EmployeeDto>>(Employees);
            return new JsonResult(EmployeesMapper);
        }
        #endregion
    }
}