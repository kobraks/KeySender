#include "stdafx.h"
#include "Shortcutcpp.h"

using namespace Core::cpp;
using namespace std;

Shortcutcpp::Shortcutcpp()
{
	name = "Name";
	message = "Write your message";
	interval = 100;
	ctr = false;
	alt = false;
	ready = false;
	shift = false;
	shortcutkey = "";
}

Shortcutcpp::Shortcutcpp(Shortcutcpp& copy)
{
	this->name = copy.name;
	this->message = copy.message;
	this->interval = copy.interval;
	this->ctr = copy.ctr;
	this->alt = copy.alt;
	this->ready = copy.ready;
	this->shift = copy.shift;
	shortcutkey = copy.shortcutkey;
}

Shortcutcpp::~Shortcutcpp()
{
}
