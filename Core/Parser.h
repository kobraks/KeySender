#pragma once
#include "Token.h"
#include "Text.h"

namespace Core
{
	namespace Parser
	{
		using namespace System;

		ref class Parser
		{
		public:
			Parser();

			array<Text::Text^>^ Parse(array<Token^>^ tokens);

		private:
			String^ Decode(String^ Code);
		};
	}
}

