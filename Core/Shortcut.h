#pragma once

namespace Core
{
	using namespace System;

	public ref class Shortcut
	{
	private:
		String^ _name, ^_message, ^_shortcutKey;
		int _interval;
		bool _ctr, _alt, _shift, _isReady;

	public:
#pragma region propertyies

		property String^ Name
		{
			String^ get()
			{
				return _name;
			}

			void set(String^ value)
			{
				_name = value;
			}
		}

		property int Interval
		{
			int get()
			{
				return _interval;
			}

			void set(int value)
			{
				this->_interval = value;
			}
		}

		property String^ Message
		{
			String^ get()
			{
				return _message;
			}

			void set(String^ value)
			{
				_message = value;
			}
		}

		property bool Ctr
		{
			bool get()
			{
				return _ctr;
			}

			void set(bool value)
			{
				_ctr = value;
			}
		}

		property bool Alt
		{
			bool get()
			{
				return _alt;
			}

			void set(bool value)
			{
				_alt = value;
			}
		}

		property bool Shift
		{
			bool get()
			{
				return _shift;
			}

			void set(bool value)
			{
				_shift = value;
			}
		}

		property bool Ready
		{
			bool get()
			{
				return _isReady;
			}

			void set(bool value)
			{
				_isReady = value;
			}
		}

		property String^ ShortcutKey
		{
			String^ get()
			{
				return _shortcutKey;
			}

			void set(String^ value)
			{
				_shortcutKey = value;
			}
		}
#pragma endregion

		Shortcut();
		~Shortcut();

		void Send();
	};
}

