#pragma once

#include "Token.h"

namespace Core
{
	namespace Parser
	{
		using namespace System;

		ref class Tokenizer
		{
		public:
			Tokenizer();

			array<Token^>^ Tokenize(String^ message);

		private:
			array<String^>^ Split(String^ message);
		};
	}
}

