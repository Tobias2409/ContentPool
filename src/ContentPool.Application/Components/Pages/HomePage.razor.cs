using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ContentPool.Application.Components.Pages;

public partial class HomePage : ComponentBase
{
    private bool isDragging = false;
    private List<IBrowserFile> selectedFiles = new();
    private bool showUploadDetailsPage = false;
    private string uploaderName = "";
    private string eventTopic = "";

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

    private void HandleAddMoreFiles(InputFileChangeEventArgs e)
    {
        foreach (var file in e.GetMultipleFiles())
        {
            selectedFiles.Add(file);
        }
    }

    private void HandleUpload()
    {
        showUploadDetailsPage = true;
    }

    private async Task HandleFinalUpload()
    {
        // TODO: Implement actual upload logic with uploaderName and eventTopic
        // For now, just clear everything
        selectedFiles.Clear();
        uploaderName = "";
        eventTopic = "";
        showUploadDetailsPage = false;
    }

    private void BackToFileList()
    {
        showUploadDetailsPage = false;
    }

    private bool IsUploadValid()
    {
        return !string.IsNullOrWhiteSpace(uploaderName) && !string.IsNullOrWhiteSpace(eventTopic);
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

    private void ClearFiles()
    {
        selectedFiles.Clear();
    }

    private void RemoveFile(IBrowserFile file)
    {
        selectedFiles.Remove(file);
    }
}