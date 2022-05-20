using Microsoft.AspNetCore.Mvc;
using PreschoolEducationApp.Interfaces;
using PreschoolEducationApp.Models;
using PreschoolEducationApp.ViewModels;

namespace PreschoolEducationApp.Controllers
{
    public class KidGroupController : Controller
    {
        private readonly IKidGroupRepository _kidGroupRepository;
        private readonly IPhotoService _photoService;

        public KidGroupController(IKidGroupRepository kidGroupRepository, IPhotoService photoService)
        {

            _kidGroupRepository = kidGroupRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            var groups = await _kidGroupRepository.GetAllAsync();
            return View(groups);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var group = await _kidGroupRepository.GetByIdAsync(id);
            return View(group);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateKidGroupModel groupVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(groupVM.Image);
                var group = new KidGroup
                {
                    Name = groupVM.Name,
                    Description = groupVM.Description,
                    GroupCategory = groupVM.GroupCategory,
                    Image = result.Url.ToString(),

                };
                _kidGroupRepository.Add(group);
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(groupVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var group = await _kidGroupRepository.GetByIdAsync(id);
            if (group == null)
                return View("Error");

            var groupVM = new EditKidGroupModel
            {
                Name = group.Name,
                Description = group.Description,
                GroupCategory = group.GroupCategory,
                URL = group.Image


            };
            return View(groupVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditKidGroupModel groupVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit group");
                return View("Edit", groupVM);
            }

            var kidGroup = await _kidGroupRepository.GetByIdAsyncNoTracking(id);
            if (kidGroup != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(kidGroup.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(groupVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(groupVM.Image);
                var group = new KidGroup
                {
                    Id = id,
                    Name = groupVM.Name,
                    Description = groupVM.Description,
                    GroupCategory = groupVM.GroupCategory,
                    Image = photoResult.Url.ToString(),


                };
                _kidGroupRepository.Update(group);
                return RedirectToAction("Index");
            }
            else
            {
                return View(groupVM);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var kidGroup = await _kidGroupRepository.GetByIdAsync(id);
            if (kidGroup == null) return View("Error");
            return View(kidGroup);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            var groupDetails = await _kidGroupRepository.GetByIdAsync(id);

            if (groupDetails == null)
            {
                return View("Error");
            }

            if (!string.IsNullOrEmpty(groupDetails.Image))
            {
                _ = _photoService.DeletePhotoAsync(groupDetails.Image);
            }

            _kidGroupRepository.Delete(groupDetails);
            return RedirectToAction("Index");
        }


    }
}
