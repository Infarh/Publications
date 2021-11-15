using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publications.BlazorUI.ViewModels
{
    public class MainViewModel
    {
        public string PageHeaderText { get; set; } = "Авторы";

        private readonly Dictionary<int, AuthorViewModel> _Authors = Enumerable.Range(1, 10)
           .Select(i => new AuthorViewModel
            {
                Id = i,
                LastName = $"Last {i}",
                FirstName = $"First {i}",
                Patronymic = $"Patr {i}",
                Birthday = DateTime.Now.AddYears(-i - 25),
                PublicationsCount = i
            })
           .ToDictionary(a => a.Id);

        public ICollection<AuthorViewModel> Authors => _Authors.Values;

        public Task<AuthorViewModel> GetAuthorById(int Id)
        {
            return Task.FromResult(_Authors.GetValueOrDefault(Id));
        }

        private readonly Dictionary<int, ICollection<PublicationViewModel>> _AuthorPublications = new();
        private readonly Dictionary<int, PublicationViewModel> _Publications = new();

        private int _LastBublicationId = 1;
        public async ValueTask<ICollection<PublicationViewModel>> GetAuthorPublications(int AuthorId)
        {
            if (await GetAuthorById(AuthorId) is not { } author) 
                return Array.Empty<PublicationViewModel>();

            await Task.Delay(5000);

            if (_AuthorPublications.TryGetValue(author.Id, out var publications))
                return publications;

            publications = Enumerable.Range(1, 20)
               .Select(i =>
                {
                    var pub = new PublicationViewModel
                    {
                        Id = _LastBublicationId,
                        Title = $"Title {_LastBublicationId}",
                        Author = author,
                        Abstract = $"Abstract {_LastBublicationId}",
                        Place = $"Place {_LastBublicationId}",
                        Date = DateTime.Now.AddMonths(-_LastBublicationId * 5)
                    };
                    _Publications[pub.Id] = pub;

                    _LastBublicationId++;
                    return pub;
                })
               .ToList();
            _AuthorPublications[author.Id] = publications;
            return publications;
        }

        public async ValueTask<PublicationViewModel> GetPublicationById(int Id)
        {
            await Task.Delay(5000);

            return _Publications.GetValueOrDefault(Id);
        }
    }
}
