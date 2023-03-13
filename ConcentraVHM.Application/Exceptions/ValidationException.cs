﻿using System;
using FluentValidation.Results;

namespace ConcentraVHM.Application.Exceptions
{
	public class ValidationException : Exception
	{
		public List<string> ValidationErrors { get; set; }
		public ValidationException(ValidationResult validationResult)
		{
			ValidationErrors = new List<string>();
			foreach (var validationError in validationResult.Errors)
			{
				ValidationErrors.Add(validationError.ErrorMessage);
			}
		}
	}
}

