// Core.h

#pragma once

#include "Shortcut.h"


namespace Core {

	using namespace System;
	using namespace System::Collections::Generic;

	public ref class Shortcuts
	{
	public:
		Shortcuts();
		~Shortcuts();

		bool Load(String^ path);
		bool Save(String^ path);

		void Add(Shortcut^ shortcut);
		void Remove(int index);
		void Change(int index, Shortcut^ shortcut);

		Shortcut^ Get(int number);
		Shortcut^ Get(String^ name);

		property int Count
		{
			int get()
			{
				return shortcuts->Count;
			}
		}
	private:
		List<Shortcut^>^ shortcuts;
	};
}
