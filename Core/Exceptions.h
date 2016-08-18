#pragma once

#include <string>
#include "Converter.h"

namespace Core
{
	namespace Exceptions
	{
		class IOException
		{
		public:
			void SetMessage(std::string message)
			{
				this->_message = message;
			}

			std::string Message()
			{
				return _message;
			}

		private:
			std::string _message;
		};

		public ref class IOExceptions : System::Exception
		{
		public:
			IOExceptions(IOException* ex) : Exception(Converter::ConvertStoManagmentS(ex->Message()))
			{}
		};
	}
}
