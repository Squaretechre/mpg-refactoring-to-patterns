#include "TestXmlBuilder.h"

#include "XmlBuilder.h"

std::unique_ptr<IOutputBuilder> TestXmlBuilder::CreateBuilder(std::string root)
{
  return std::unique_ptr<IOutputBuilder>(new XmlBuilder(root));
}