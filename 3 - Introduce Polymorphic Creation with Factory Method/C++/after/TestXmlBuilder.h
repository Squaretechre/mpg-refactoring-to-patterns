#ifndef TESTXMLBUILDER_H
#define TESTXMLBUILDER_H

#include "IOutputBuilder.h"
#include "ITestBuilder.h"

class TestXmlBuilder : public ITestBuilder
{
public:
  void TestAddAboveRoot();
private:
  std::unique_ptr<IOutputBuilder> Builder;
  std::unique_ptr<IOutputBuilder> CreateBuilder(std::string root);
};

#endif