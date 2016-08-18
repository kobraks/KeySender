#pragma once

namespace Core
{
	namespace Text
	{
		using namespace System;

		ref class Text
		{
		private:
			bool _special;
			String^ _text;
		public:
			property bool IsSpecialValue
			{
				bool get()
				{
					return _special;
				}

				void set(bool value)
				{
					_special = value;
				}
			}

			property String^ Message
			{
				String^ get()
				{
					return _text;
				}

				void set(String^ value)
				{
					_text = value;
				}
			}

			Text(String^ text) : _text(text), _special(false) {}
			Text(String^ text, bool special) : _text(text), _special(special) {}
			Text() : _text(""), _special(false) {}

			void Send(int interval);
		};
	}
}