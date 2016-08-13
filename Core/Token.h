#pragma once

namespace Core
{
	namespace Parser
	{
		using namespace System;

		ref class Token
		{
		public:
			Token() : _value(""), _key(' ') {}
			Token(String^ value, char key) : _value(value), _key(key) {}
			Token(String^ value) : _value(value), _key(' ') {}

			property String^ Value
			{
				String^ get()
				{
					return _value;
				}

				void set(String^ value)
				{
					_value = value;
				}
			}

			property char Key
			{
				char get()
				{
					return _key;
				}

				void set(char value)
				{
					_key = value;
				}
			}

		private:
			String^ _value;
			char _key;
		};
	}
}


