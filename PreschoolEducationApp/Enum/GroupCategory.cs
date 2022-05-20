using System.ComponentModel.DataAnnotations;

namespace PreschoolEducationApp.Enum
{
    public enum GroupCategory
    {

        [Display(Name = "Младшая группа")]
        LevelOne,
        [Display(Name = "Средняя группа")]
        LevelTwo,
        [Display(Name = "Старшая группа")]
        LevelThree,
        
    }



}
