#include "Stdafx.h"
#include "Converter.h"
#include <msclr\marshal_cppstd.h>
#include <locale>
#include <codecvt>

using namespace std;
using namespace System;

string Core::Converter::ConvertManagmentStoS(String^ stringToConvert)
{
	return msclr::interop::marshal_as<string>(stringToConvert);
}

String^ Core::Converter::ConvertStoManagmentS(string stringToConvert)
{
	return gcnew String(stringToConvert.c_str());
}

string Core::Converter::ConvertWStoS(wstring stringToConvert)
{
	string tmp;

	std::wstring_convert<std::codecvt_utf8_utf16<wchar_t>> converter;
	tmp = converter.to_bytes(stringToConvert);

	return tmp;
}

wstring Core::Converter::ConvertStoWS(string stringToConvert)
{
	wstring tmp(stringToConvert.begin(), stringToConvert.end());
	return tmp;
}

