using BookAndRent.Models.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository.SqlRepository
{
    public enum Facility
    {
        WiFi = 1,
        Лифт = 2,
        Фен = 4,
        Утюг = 8,
        Отопление = 16,
        Кухня = 32,
        Парковка = 64,
        Телевизор = 128,
        Кондиционер = 256,
        Кабельное = 512
    }
}
