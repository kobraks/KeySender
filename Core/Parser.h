#pragma once
#include "Token.h"

namespace Core
{
	namespace Parser
	{
		using namespace System;

		ref class Parser
		{
		public:
			Parser();

			array<String^>^ Parse(array<Token^>^ tokens);

		private:
			String^ Decode(String^ Code);
		};
	}
}

