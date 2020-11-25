using AutoMapper;
using LeilaoNet.Application.Leiloes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoNet.IoC.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static Type[] Setup()
        {
            var profiles = RegisterMappings();
            return profiles.Select(c => c.GetType()).ToArray();
        }

        public static IEnumerable<Profile> RegisterMappings()
        {
            yield return new LeilaoMappingProfile();
        }
    }
}