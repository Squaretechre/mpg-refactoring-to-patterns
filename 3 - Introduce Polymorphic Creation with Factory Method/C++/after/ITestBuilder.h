#ifndef ITESTBUILDER_H
#define ITESTBUILDER_H

#include <gtest/gtest.h>

class ITestBuilder :  public testing::Test
{
public:
  void TestAddAboveRoot()
  {
    builder = CreateBuilder("orders");
    ASSERT_NO_THROW(builder->AddBelow("customer"));
    ASSERT_ANY_THROW(builder->AddAbove("customer"));
  };
protected:
  std::unique_ptr<IOutputBuilder> builder;
  virtual std::unique_ptr<IOutputBuilder> CreateBuilder(std::string root) = 0;
};

#endif