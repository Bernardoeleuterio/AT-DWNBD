using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO; 
using System.Collections.Generic;
using System.Linq;

namespace AT_DWNBD.Pages.Notas
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        [BindProperty]
        public string NoteTitle { get; set; } = string.Empty; 

        [BindProperty]
        public string NoteContent { get; set; } = string.Empty; 

        public List<string> AvailableNotes { get; set; } = new List<string>(); 
        public string SelectedNoteContent { get; set; } = string.Empty; 

        public ViewNotesModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet()
        {
            LoadAvailableNotes();
        }

        public IActionResult OnPostCreateNote()
        {
            if (string.IsNullOrWhiteSpace(NoteTitle) || string.IsNullOrWhiteSpace(NoteContent))
            {
                ModelState.AddModelError("", "Título e conteúdo da nota são obrigatórios.");
                LoadAvailableNotes(); 
                return Page();
            }

            string filesPath = Path.Combine(_environment.WebRootPath, "files");

            Directory.CreateDirectory(filesPath);

            string safeFileName = SanitizeFileName(NoteTitle) + ".txt";
            string filePath = Path.Combine(filesPath, safeFileName);

            try
            {
                System.IO.File.WriteAllText(filePath, NoteContent);
                TempData["SuccessMessage"] = $"Nota '{NoteTitle}' salva com sucesso!";
                NoteTitle = string.Empty; 
                NoteContent = string.Empty;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Erro ao salvar a nota: {ex.Message}");
            }

            LoadAvailableNotes();
            return Page();
        }

        public IActionResult OnGetViewNote(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                ModelState.AddModelError("", "Nome do arquivo inválido para visualização.");
                LoadAvailableNotes();
                return Page();
            }

            string filesPath = Path.Combine(_environment.WebRootPath, "files");
            string filePath = Path.Combine(filesPath, fileName);

            if (System.IO.File.Exists(filePath) && Path.GetFullPath(filePath).StartsWith(filesPath, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    SelectedNoteContent = System.IO.File.ReadAllText(filePath);
                }
                catch (Exception ex)
                {
                    SelectedNoteContent = $"Erro ao ler o arquivo: {ex.Message}";
                }
            }
            else
            {
                SelectedNoteContent = "Arquivo não encontrado ou acesso negado.";
            }

            LoadAvailableNotes();
            return Page();
        }

        private void LoadAvailableNotes()
        {
            string filesPath = Path.Combine(_environment.WebRootPath, "files");

            if (Directory.Exists(filesPath))
            {
                AvailableNotes = Directory.GetFiles(filesPath, "*.txt")
                                        .Select(Path.GetFileName)
                                        .ToList();
            }
            else
            {
                AvailableNotes = new List<string>();
            }
        }

        private string SanitizeFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }
            return fileName.Length > 100 ? fileName.Substring(0, 100) : fileName;
        }
    }
}