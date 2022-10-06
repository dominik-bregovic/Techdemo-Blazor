/**
 * Title:            BlazorApiProject
 * class:			 Employee.cs
 * Author:           Dominik Bregovic
 * Email:            dominik.bregovic@edu.fh-joanneum.at
 * Semester:         4
 * Last Change:      06.10.2022
 * Description:      Is our data model. Here We add the properties to our model
 */

namespace MyModels.Models
{
    public class Employee
    {
        
        public int EmpId { get; set; }
        public string Name { get; set; }

        public int Index { get; set; }
    }
}
