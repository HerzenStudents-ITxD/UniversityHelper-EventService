using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityHelper.EventService.Broker.Requests.Interfaces;
using UniversityHelper.EventService.Business.Commands.File.Interfaces;
using UniversityHelper.EventService.Data.Interfaces;
using UniversityHelper.EventService.Mappers.Models.Interfaces;
using UniversityHelper.EventService.Models.Db;
using UniversityHelper.EventService.Models.Dto.Models;
using UniversityHelper.EventService.Models.Dto.Requests.File;
using UniversityHelper.Core.Responses;
using UniversityHelper.Models.Broker.Models.File;

namespace UniversityHelper.EventService.Business.Commands.File;

public class FindFilesCommand : IFindFilesCommand
{
  private readonly IFileRepository _repository;
  private readonly IFileService _fileService;
  private readonly IFileInfoMapper _fileMapper;

  public FindFilesCommand(
    IFileRepository repository,
    IFileService fileService,
    IFileInfoMapper fileMapper)
  {
    _repository = repository;
    _fileService = fileService;
    _fileMapper = fileMapper;
  }

  public async Task<FindResultResponse<FileInfo>> ExecuteAsync(FindFilesFilter findFilter)
  {
    (List<DbFile> dbFiles, int totalCount) = await _repository.FindAsync(findFilter);

    List<FileCharacteristicsData> files = await _fileService.GetFilesCharacteristicsAsync(dbFiles?.ConvertAll(file => file.FileId));

    return new FindResultResponse<FileInfo>(
      body: files?.ConvertAll(_fileMapper.Map),
      totalCount: totalCount);
  }
}
