#pragma once
#include "Shortcutcpp.h"
#include "Converter.h"

namespace Core
{
	using namespace System;

	public ref class Shortcut
	{
	private:
		Core::cpp::Shortcutcpp* shortcut;

	public:
#pragma region propertyies

		property String^ Name
		{
			String^ get()
			{
				return Core::Converter::ConvertStoManagmentS(shortcut->GetName());
			}

			void set(String^ value)
			{
				shortcut->SetName(Core::Converter::ConvertManagmentStoS(value));
			}
		}

		property int Interval
		{
			int get()
			{
				return shortcut->GetInterval();
			}

			void set(int value)
			{
				shortcut->SetInterval(value);
			}
		}

		property String^ Message
		{
			String^ get()
			{
				return Core::Converter::ConvertStoManagmentS(shortcut->GetMessage());
			}

			void set(String^ value)
			{
				shortcut->SetMessage(Core::Converter::ConvertManagmentStoS(value));
			}
		}

		property bool Ctr
		{
			bool get()
			{
				return shortcut->GetCtr();
			}

			void set(bool value)
			{
				shortcut->SetCtr(value);
			}
		}

		property bool Alt
		{
			bool get()
			{
				return shortcut->GetAlt();
			}

			void set(bool value)
			{
				shortcut->SetAlt(value);
			}
		}

		property bool Shift
		{
			bool get()
			{
				return shortcut->GetShift();
			}

			void set(bool value)
			{
				shortcut->SetShift(value);
			}
		}

		property bool Ready
		{
			bool get()
			{
				return shortcut->GetReady();
			}

			void set(bool value)
			{
				shortcut->SetReady(value);
			}
		}

		property String^ ShortcutKey
		{
			String^ get()
			{
				return Core::Converter::ConvertStoManagmentS(shortcut->GetShortcutKey());
			}

			void set(String^ value)
			{
				shortcut->SetShortcutKey(Core::Converter::ConvertManagmentStoS(value));
			}
		}
#pragma endregion

		Core::cpp::Shortcutcpp* GetShortcutcpp();

		Shortcut();
		Shortcut(Core::cpp::Shortcutcpp* shortcutcpp);
		~Shortcut();

		void Send();
	};
}

