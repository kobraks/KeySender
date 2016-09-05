#pragma once
#include <vector>
#include <string>
#include <iostream>
#include "Shortcutcpp.h"
#include "Exceptions.h"

namespace Core
{
	namespace cpp
	{
		class Shortcutscpp
		{
		public:
			Shortcutscpp();
			~Shortcutscpp();

			void Clear();

			Shortcutcpp* Get(std::string name);
			Shortcutcpp* Get(int index);
			Shortcutcpp* operator[](int index);

			void Add(Shortcutcpp* shortcut);
			void Remove(int index);
			void Remove(std::string name);
			void Change(int indxex, Shortcutcpp* shortcut);

			int Size();

			bool Load(std::string path);
			bool Save(std::string path);

			const std::string VERSION = "1.0.0";

			friend std::ostream& operator<< (std::ostream& out, const Shortcutscpp& s)
			{
				//Write a file header
				out.write((char*)"KESE", sizeof("KESE"));

				size_t size = s.VERSION.size();
				System::Diagnostics::Debug::WriteLine(size);
				out.write(reinterpret_cast<const char*>(&size), sizeof(s.VERSION.size()));
				out.write(s.VERSION.c_str(), size);
				
				size = s.shortcuts.size();
				out.write(reinterpret_cast<const char*>(&size), sizeof(s.shortcuts.size()));
				

				for (auto element : s.shortcuts)
				{
					out << *element;
				}

				return out;
			}

			friend std::istream& operator >> (std::istream& in, Shortcutscpp& s)
			{
				//Read a file hader
				{
					char* tmp = new char[5];
					in.read(tmp, 5);

					if (std::string(tmp) != "KESE")
					{
						auto ex = new Exceptions::IOException();
						ex->SetMessage("Unable to read file, file is corupted");
						throw gcnew Exceptions::IOExceptions(ex);
					}
					delete[] tmp;

					size_t size = 0;
					in.read((char*)&size, sizeof(s.VERSION.size()));
					System::Diagnostics::Debug::WriteLine(size);

					tmp = new char[size];
					in.read(tmp, size);
					std::string fileVer;
					for (int i = 0; i < size; i++)
					{
						fileVer += tmp[i];
					}

					if (fileVer != s.VERSION)
					{
						auto ex = new Exceptions::IOException();
						ex->SetMessage("This file is too old");
						throw gcnew Exceptions::IOExceptions(ex);
					}
					delete[] tmp;
				}

				auto tmp = s.shortcuts.size();
				in.read(reinterpret_cast<char*>(&tmp), sizeof(tmp));

				for (int i = 0; i < tmp; i++)
				{
					Shortcutcpp* c = new Shortcutcpp();
					in >> *c;
					s.Add(c);
				}

				return in;
			}

		private:
			std::vector<Shortcutcpp*> shortcuts;

		};
	}
}

