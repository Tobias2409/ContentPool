using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ContentPool.Application.Components.Pages;

public partial class HomePage : ComponentBase
{
    private bool isDragging = false;
    private List<IBrowserFile> selectedFiles = new();

    private void HandleDragEnter()
    {
        isDragging = true;
    }

    private void HandleDragLeave()
    {
        isDragging = false;
    }

    private void HandleDrop()
    {
        isDragging = false;
    }

    private void HandleFileSelected(InputFileChangeEventArgs e)
    {
        selectedFiles.Clear();
        foreach (var file in e.GetMultipleFiles())
        {
            selectedFiles.Add(file);
        }
    }

    private async Task HandleUpload()
    {
        // TODO: Implement upload logic
        // For now, just clear the selected files
        selectedFiles.Clear();
    }

    private string GetDropZoneClass()
    {
        return isDragging
            ? "border-primary-600 bg-primary-50"
            : "border-gray-300 bg-white hover:border-primary-600 hover:bg-primary-50";
    }

    private string FormatFileSize(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB" };
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }
}