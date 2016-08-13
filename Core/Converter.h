#pragma once
#include <string>

namespace Core
{
	namespace Converter
	{
		using namespace System;

		inline std::string ConvertManagmentStoS(String^ stringToConvert);
		inline String^ ConvertStoManagmentS(std::string stringToConvert);

		inline std::string ConvertWStoS(std::wstring stringToConver);
		inline std::wstring ConvertStoWS(std::string stringToConver);
	}
}
