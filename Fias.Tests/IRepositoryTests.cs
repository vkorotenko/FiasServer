#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.07.2020 19:45
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using VKorotenko.FiasServer.Bl.Abstraction;
using Xunit;

namespace Fias.Tests
{
    public class RepositoryTests
    {
        private class Test
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
        private class TestRepository : IRepository<Test, int>
        {
            private List<Test> _items = new List<Test>();
            public void Add(Test item)
            {
                _items.Add(item);
            }
            public void AddRange(IEnumerable<Test> items)
            {
                _items.AddRange(items);
            }


            public Test Get(int key)
            {
                return _items.First(x => x.Id == key);
            }

            public IEnumerable<Test> All()
            {
                return _items;
            }

            public IEnumerable<Test> Where(Func<Test, bool> query)
            {
                return _items.Where(query);
            }


        }
        [Fact]
        public void AddItemTest()
        {
            var rep = new TestRepository();
            var items = GetTestItems();
            rep.Add(items.First());
        }
        [Fact]
        public void AddItemsTest()
        {
            var rep = new TestRepository();
            var items = GetTestItems();
            rep.AddRange(items);
        }
        
        [Fact]
        public void AddWhereTest()
        {
            IRepository<Test,int> rep = new TestRepository();
            var items = GetTestItems();
            rep.AddRange(items);
            var result  = rep.Where(x => x.Name == "test3");
            Assert.Single(result);
            var record3 = result.First();
            Assert.Equal("test3",record3.Name);
        }

        private static IEnumerable<Test> GetTestItems()
        {
            return new Test[]
            {
                new Test{Description = "test1 description",Id = 1, Name = "test1"},
                new Test{Description = "test2 description",Id = 2, Name = "test2"},
                new Test{Description = "test3 description",Id = 3, Name = "test3"},
            };
        }

    }
}
