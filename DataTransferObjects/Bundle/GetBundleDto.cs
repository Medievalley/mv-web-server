﻿namespace DataTransferObjects.BundleDTOs
{
    public class GetBundleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Discount { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
