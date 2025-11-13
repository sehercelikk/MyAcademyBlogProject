using AutoMapper;
using Blogy.Business.DTOS.CommentDtos;
using Blogy.DataAccess.Repositories.CommentRepositories;
using Blogy.Entities.Concrete;
using FluentValidation;

namespace Blogy.Business.Services.CommentService;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<Comment> _validator;

    public CommentService(ICommentRepository commentRepository, IMapper mapper = null, IValidator<Comment> validator = null)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task CreateAsync(CreateCommentDto createDto)
    {
        var mapEntity = _mapper.Map<Comment>(createDto);
        var validComment = await _validator.ValidateAsync(mapEntity);
        if (!validComment.IsValid)
        {
            throw new ValidationException(validComment.Errors);
        }
        await _commentRepository.AddAsync(mapEntity);
    }

    public async Task DeleteAsync(int id)
    {
        await _commentRepository.DeleteAsync(id);
    }

    public async Task<ResultCommentDto> GetSingleIdAsync(int id)
    {
        var entity = await _commentRepository.GetByIdAsync(id);
        return _mapper.Map<ResultCommentDto>(entity);
    }

    public async Task<List<ResultCommentDto>> GetAllAsync()
    {
        var result= await _commentRepository.GetAllAsync();
        return _mapper.Map<List<ResultCommentDto>>(result);
    }

    public async Task<UpdateCommentDto?> GetByIdAsync(int id)
    {
        var entity = await _commentRepository.GetByIdAsync(id);
        return _mapper.Map<UpdateCommentDto>(entity);
    }

    public async Task UpdateAsync(UpdateCommentDto updateDto)
    {
        var mapEntity= _mapper.Map<Comment>(updateDto);
        var validComment =await  _validator.ValidateAsync(mapEntity);
        if (!validComment.IsValid)
        {
            throw new ValidationException(validComment.Errors);
        }
        await _commentRepository.UpdateAsync(mapEntity);
    }
}
