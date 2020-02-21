#include "XmlBuilder.h"

#include <string>

XmlBuilder::XmlBuilder(std::string root) : Root(root) {};

void XmlBuilder::AddBelow(std::string tag)
{
}

void XmlBuilder::AddAbove(std::string tag)
{
  throw 0;
}