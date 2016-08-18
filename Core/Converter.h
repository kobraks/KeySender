#pragma once
#include <string>

namespace Core
{
	namespace Converter
	{
		using namespace System;

		std::string ConvertManagmentStoS(String^ stringToConvert);
		String^ ConvertStoManagmentS(std::string& stringToConvert);

		std::string ConvertWStoS(std::wstring& stringToConver);
		std::wstring ConvertStoWS(std::string& stringToConver);
	}
}
