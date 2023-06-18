﻿using System;
namespace BAPDS.Service
{
	public interface INavigationService
	{
		Task NavigateToAsync(string route, IDictionary<string, object> parameters = null);
	}
}

