#pragma once
#include <iostream>
#include <string>

namespace Core
{
	namespace cpp
	{
		class Shortcutcpp
		{
		public:
			Shortcutcpp();
			Shortcutcpp(Shortcutcpp& shortcutcpp);
			~Shortcutcpp();

			std::string GetName()
			{
				return this->name;
			}

			void SetName(std::string& name)
			{
				this->name = name;
			}

			std::string GetMessage()
			{
				return message;
			}

			void SetMessage(std::string& message)
			{
				this->message = message;
			}

			std::string GetShortcutKey()
			{
				return shortcutkey;
			}

			void SetShortcutKey(std::string&shorcutkey)
			{
				this->shortcutkey = shorcutkey;
			}
			
			int GetInterval()
			{
				return interval;
			}

			void SetInterval(int& interval)
			{
				this->interval = interval;
			}

			bool GetCtr()
			{
				return ctr;
			}

			void SetCtr(bool& ctr)
			{
				this->ctr = ctr;
			}

			bool GetAlt()
			{
				return alt;
			}

			void SetAlt(bool& alt)
			{
				this->alt = alt;
			}

			bool GetShift()
			{
				return shift;
			}

			void SetShift(bool& shift)
			{
				this->shift = shift;
			}

			bool GetReady()
			{
				return ready;
			}

			void SetReady(bool& ready)
			{
				this->ready = ready;
			}

			friend std::ostream& operator<< (std::ostream& out, const Core::cpp::Shortcutcpp& s)
			{
				//Write a name
				size_t size = s.name.size();
				out.write(reinterpret_cast<const char*>(&size), sizeof(s.name.size()));
				out.write(s.name.c_str(), s.name.size());

				//Write message
				size = s.message.size();
				out.write(reinterpret_cast<const char*>(&size), sizeof(s.message.size()));
				out.write(s.message.c_str(), s.message.size());

				//Write shortcutkey
				size = s.shortcutkey.size();
				out.write(reinterpret_cast<const char*>(&size), sizeof(s.shortcutkey.size()));
				out.write(s.shortcutkey.c_str(), s.shortcutkey.size());

				//Write interval
				out.write(reinterpret_cast<const char*>(&s.interval), sizeof(s.interval));

				//Write ctr
				out.write(reinterpret_cast<const char*>(&s.ctr), sizeof(s.ctr));

				//write alt
				out.write(reinterpret_cast<const char*>(&s.alt), sizeof(s.alt));

				//write shift
				out.write(reinterpret_cast<const char*>(&s.shift), sizeof(s.shift));

				//write ready
				out.write(reinterpret_cast<const char*>(&s.ready), sizeof(s.ready));

				return out;
			}

			friend std::istream& operator >> (std::istream& in, Core::cpp::Shortcutcpp& s)
			{
				char* buff;

				//Read name
				{
					size_t tmp;
					in.read((char*)&tmp, sizeof(s.name.size()));

					buff = new char[tmp];
					in.read(buff, tmp);
					s.name = "";
					for (int i = 0; i < tmp; i++)
						s.name += buff[i];
					delete [] buff;
				}
				
				//Read message
				{
					size_t tmp;
					in.read((char*)&tmp, sizeof(s.message.size()));

					buff = new char[tmp];
					in.read(buff, tmp);
					s.message = "";
					for (int i = 0; i < tmp; i++)
						s.message += buff[i];
					delete [] buff;
				}

				//Read shortcutKey
				{
					size_t tmp;
					in.read((char*)&tmp, sizeof(s.shortcutkey.size()));

					buff = new char[tmp];
					in.read(buff, tmp);
					s.shortcutkey = "";
					for (int i = 0; i < tmp; i++)
						s.shortcutkey += buff[i];
					delete [] buff;
				}

				//Read interval
				in.read((char*)&s.interval, sizeof(s.interval));

				//read ctr
				in.read((char*)&s.ctr, sizeof(s.ctr));

				//read alt
				in.read((char*)&s.alt, sizeof(s.alt));

				//read shift
				in.read((char*)&s.shift, sizeof(s.shift));

				//read ready
				in.read((char*)&s.ready, sizeof(s.ready));

				return in;
			}

		private:
			std::string name, message, shortcutkey;
			int interval;
			bool ctr, alt, shift, ready;
		};
	}
}


