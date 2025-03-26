using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using RestApi.Models;

namespace RestApi
{
    public class Validator : AbstractValidator<Car>
    {
        private readonly List<Car> _carList;
        public Validator(){

            RuleFor(Car => Car.Brand)
                .NotEmpty()
                .WithMessage("Brand is required");
            RuleFor(Car => Car.Model)
                .NotEmpty()
                .WithMessage("Model is required");
            RuleFor(Car => Car.Year)
                .NotEmpty()
                .WithMessage("Year is required");
            RuleFor(static Car => Car.Price)
                .NotEmpty()
                .WithMessage("Price is required");
        }
    
    }
}